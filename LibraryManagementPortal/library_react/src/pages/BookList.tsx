import { useEffect, useState } from "react";
import { useHistory } from "react-router";
import { useLocation } from "react-router-dom";
import BookItem from "../components/BookItem";
import Pagination from "../components/Pagination";
import Book from "../models/Book";
import PaginationInfo from "../models/PaginationInfo";
import StringResource from "../resources/StringResource";
import APICaller from "../services/APICaller.service";

export default function Books() {
    const history = useHistory();
    const [books, setBooks] = useState<Book[]>([]);
    const [pagination, setPagination] = useState<PaginationInfo>({
        link: StringResource.linkBookList,
        page: 1,
        limit: 10,
        totalPage: 1,
    });

    let query = new URLSearchParams(useLocation().search);

    if (!query.get("page")) {
        history.replace({
            pathname: StringResource.linkBookList,
            search: "?page=1&limit=10",
        });
    }

    const page = Number.parseInt(query.get("page")!);
    const limit = Number.parseInt(query.get("limit")!);

    const [firstIndex, setFirstIndex] = useState(0);

    useEffect(() => {
        (async () => {
            const booksData: {
                books: Book[];
                totalBooks: number;
                page: number;
                limit: number;
            } = await APICaller.getBooks(
                isNaN(page) ? 1 : page,
                isNaN(limit) ? 10 : limit
            );

            setBooks(booksData.books);

            var totalPage = Math.ceil(booksData.totalBooks / booksData.limit);

            setPagination({
                link: StringResource.linkBookList,
                page: booksData.page,
                limit: booksData.limit,
                totalPage: totalPage,
            });

            setFirstIndex((booksData.page - 1) * limit);
        })();
    }, [page]);

    console.log(pagination);

    let indexIncrement = 0;
    return (
        <div className="container mt-5">
            <div className="row">
                <h2 className="w-100 text-center">Book List</h2>
                <table className="table table-striped mt-5">
                    <thead>
                        <tr>
                            <th scope="col">#</th>
                            <th scope="col">Title</th>
                            <th scope="col">Author</th>
                            <th scope="col">Category</th>
                        </tr>
                    </thead>
                    <tbody>
                        {books.map((b) => (
                            <BookItem
                                book={b}
                                index={firstIndex + ++indexIncrement}
                                key={b.id}
                            />
                        ))}
                    </tbody>
                </table>
                <Pagination {...pagination} />
            </div>
        </div>
    );
}