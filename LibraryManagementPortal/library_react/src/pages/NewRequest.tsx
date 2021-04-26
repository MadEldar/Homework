import { useEffect, useState } from "react";
import { useHistory, useLocation } from "react-router-dom";
import BookItem from "../components/BookItem";
import Pagination from "../components/Pagination";
import { getSavedBookIds } from "../helpers/LocalStorageHelper";
import Book from "../models/Book";
import PaginationInfo from "../models/PaginationInfo";
import StringResource from "../resources/StringResource";
import APICaller from "../services/APICaller.service";

export default function NewRequest() {
    const history = useHistory();
    const [requestBooks, setRequestBooks] = useState<Book[]>([]);
    const [pagination, setPagination] = useState<PaginationInfo>({
        link: StringResource.linkNewRequest,
        page: 1,
        limit: 10,
        totalPage: 1,
    });

    let query = new URLSearchParams(useLocation().search);

    if (!query.get("page") && !query.get("limit")) {
        history.replace({
            pathname: StringResource.linkNewRequest,
            search: "?page=1&limit=10",
        });
    }

    const page = Number.parseInt(query.get("page")!);
    const limit = Number.parseInt(query.get("limit")!);

    useEffect(() => {
        (async () => {
            const bookIds = getSavedBookIds();

            if (bookIds.length === 0) {
                setRequestBooks([]);
            } else {
                const response = await APICaller.getBooksByIds(bookIds, page, limit).then();

                setRequestBooks(response.books);

                var totalPage = Math.ceil(response.totalBooks / response.limit);
    
                setPagination({
                    link: StringResource.linkNewRequest,
                    page: response.page,
                    limit: response.limit,
                    totalPage: totalPage,
                });
            }
        })();
    }, [page, limit]);

    let indexIncrement = (page - 1) * limit;

    async function sendBookRequest(e: any) {
        e.preventDefault();
        const formData = new FormData(e.target);

        const ids: string[] = formData.getAll("ids").map(id => id.toString());

        const result = await APICaller.postRequest(ids).then();
    }

    return (
        <div className="container mt-5">
            <form id="requestForm" className="row" onSubmit={sendBookRequest}>
                <h2 className="w-100 text-center">Saved books</h2>
                <table className="table table-striped mt-5">
                    <thead>
                        <tr>
                            <th scope="col" className=" text-center">
                                #
                            </th>
                            <th scope="col" className=" text-center">
                                Title
                            </th>
                            <th scope="col" className=" text-center">
                                Author
                            </th>
                            <th scope="col" className=" text-center">
                                Category
                            </th>
                            <th scope="col" className=" text-center">
                                Action
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        {requestBooks.length > 0 ? (
                            requestBooks.map((b) => (
                                <BookItem
                                    book={b}
                                    index={++indexIncrement}
                                    key={b.id}
                                    isAdmin={false}
                                    hasRequest={true}
                                />
                            ))
                        ) : (
                            <p className="text-center">
                                There is no book saved in your request
                            </p>
                        )}
                    </tbody>
                </table>
                <div className="col-12">
                    <Pagination className="float-left" {...pagination} />
                    <button className="btn btn-primary float-right mr-2">
                        Request books
                    </button>
                </div>
            </form>
        </div>
    );
}
