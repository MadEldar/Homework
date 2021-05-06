import { useEffect, useState } from "react";
import { useHistory, useLocation } from "react-router-dom";
import BookItem from "../components/BookItem";
import Pagination from "../components/Pagination";
import { getSavedBookIds } from "../helpers/LocalStorageHelper";
import ParamBuilder from "../helpers/ParamBuilder";
import Book from "../models/Book";
import PaginationInfo from "../models/PaginationInfo";
import StringResource from "../resources/StringResource";
import APICaller from "../services/APICaller.service";

export default function SavedBooks() {
    const history = useHistory();
    const pathname = history.location.pathname;
    const [requestBooks, setRequestBooks] = useState<Book[]>([]);
    const [pagination, setPagination] = useState<PaginationInfo>({
        link: pathname,
        page: 1,
        limit: 10,
        totalPage: 1,
    });

    let query = new URLSearchParams(useLocation().search);

    if (!query.get("page") || !query.get("limit")) {
        history.replace({
            pathname: pathname,
            search: ParamBuilder({
                page: "1",
                limit: "10",
            }),
        });
    }

    const page = Number.parseInt(query.get("page")!) || 1;
    const limit = Number.parseInt(query.get("limit")!) || 10;

    useEffect(() => {
        (async () => {
            const bookIds = getSavedBookIds();

            setRequestBooks([]);

            if (bookIds.length > 0) {
                const response = await APICaller.getBooksByIds(
                    bookIds,
                    page,
                    limit
                ).then();

                setRequestBooks(response.books);

                var totalPage = Math.ceil(response.totalBooks / response.limit);

                setPagination({
                    link: pathname,
                    page: response.page,
                    limit: response.limit,
                    totalPage: totalPage,
                });
            }
        })();
    }, [page, limit, pathname]);

    let indexIncrement = (page - 1) * limit;

    async function sendBookRequest(e: any) {
        e.preventDefault();

        const formData = new FormData(e.target);

        const ids: string[] = formData.getAll("ids").map((id) => id.toString());

        const response = await APICaller.postRequest(ids).then();

        if (response.statusCode === 201) {
            history.push(StringResource.linkUserProfile);
        }
    }

    return (
        <div className="container mt-5">
            {requestBooks.length > 0 ? (
                <form
                    id="requestForm"
                    className="row"
                    onSubmit={sendBookRequest}
                >
                    <h2 className="w-100 text-center">Saved books</h2>
                    <table className="table table-striped mt-5">
                        <thead>
                            <tr>
                                <th scope="col" className="text-center">
                                    #
                                </th>
                                <th scope="col">
                                    Title
                                </th>
                                <th scope="col">
                                    Author
                                </th>
                                <th scope="col">
                                    Category
                                </th>
                                <th scope="col" className="text-center">
                                    Action
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            {requestBooks.map((b) => (
                                <BookItem
                                    book={b}
                                    index={++indexIncrement}
                                    key={b.id}
                                    isAdmin={false}
                                    hasRequest={true}
                                />
                            ))}
                        </tbody>
                    </table>
                    <div className="col-12">
                        <Pagination className="float-left" {...pagination} />
                        <button className="btn btn-primary float-right mr-2">
                            Request books
                        </button>
                    </div>
                </form>
            ) : (
                <h5 className="text-center">You haven't saved any book</h5>
            )}
        </div>
    );
}
