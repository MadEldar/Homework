import { useEffect, useState } from "react";
import { useHistory } from "react-router";
import { useLocation } from "react-router-dom";
import BookItem from "../components/BookItem";
import Pagination from "../components/Pagination";
import ParamBuilder from "../helpers/ParamBuilder";
import Book from "../models/Book";
import PaginationInfo from "../models/PaginationInfo";
import StringResource from "../resources/StringResource";
import APICaller from "../services/APICaller.service";

export default function BookList() {
    const history = useHistory();
    const [books, setBooks] = useState<Book[]>([]);
    const [pagination, setPagination] = useState<PaginationInfo>({
        link: StringResource.linkBook,
        page: 1,
        limit: 10,
        totalPage: 1,
    });

    let query = new URLSearchParams(useLocation().search);

    if (!query.get("page") || !query.get("limit")) {
        history.replace({
            pathname: StringResource.linkBook,
            search: ParamBuilder({
                page: "1",
                limit: "10",
            }),
        });
    }

    const page = Number.parseInt(query.get("page")!) || 1;
    const limit = Number.parseInt(query.get("limit")!) || 10;

    const [firstIndex, setFirstIndex] = useState(0);

    useEffect(() => {
        (async () => {
            const booksData: {
                books: Book[];
                totalBooks: number;
                page: number;
                limit: number;
            } = await APICaller.getBookList(
                isNaN(page) ? 1 : page,
                isNaN(limit) ? 10 : limit
            );

            setBooks(booksData.books);

            var totalPage = Math.ceil(booksData.totalBooks / booksData.limit);

            setPagination({
                link: StringResource.linkBook,
                page: booksData.page,
                limit: booksData.limit,
                totalPage: totalPage,
            });

            setFirstIndex((booksData.page - 1) * limit);
        })();
    }, [page, limit]);

    let indexIncrement = 0;
    
    return (
        <div className="container mt-5">
            <div className="row">
                <h2 className="w-100 text-center">Book List</h2>
                <table className="table table-striped mt-5">
                    <thead>
                        <tr>
                            <th scope="col" className=" text-center">#</th>
                            <th scope="col" className=" text-center">Title</th>
                            <th scope="col" className=" text-center">Author</th>
                            <th scope="col" className=" text-center">Category</th>
                            <th scope="col" className=" text-center">Action</th>
                        </tr>
                    </thead>
                    <tbody>
                        {books.map((b) => (
                            <BookItem
                                book={b}
                                index={isNaN(firstIndex) ? 0 : firstIndex + ++indexIncrement}
                                key={b.id}
                                isAdmin={false}
                                hasRequest={false}
                            />
                        ))}
                    </tbody>
                </table>
                <Pagination {...pagination} />
            </div>
        </div>
    );
}
