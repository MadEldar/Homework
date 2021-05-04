import { useEffect, useState } from "react";
import { useHistory } from "react-router";
import { useLocation } from "react-router-dom";
import BookItem from "../components/BookItem";
import Pagination from "../components/Pagination";
import ParamBuilder from "../helpers/ParamBuilder";
import Book from "../models/Book";
import PaginationInfo from "../models/PaginationInfo";
import APICaller from "../services/APICaller.service";

export default function BookList({initBooks}: {initBooks?: Book[]}) {
    const history = useHistory();
    const pathname = history.location.pathname;

    const query = new URLSearchParams(useLocation().search);
    const page = Number.parseInt(query.get("page")!) || 1;
    const limit = Number.parseInt(query.get("limit")!) || 10;

    const [books, setBooks] = useState<Book[]>(initBooks ?? []);
    const [pagination, setPagination] = useState<PaginationInfo>({
        link: pathname,
        page: 1,
        limit: 10,
        totalPage: 1,
    });
    const hasBooks = initBooks && initBooks.length > 0;

    if (!hasBooks) {    
        if (!query.get("page") || !query.get("limit")) {
            history.replace({
                pathname: pathname,
                search: ParamBuilder({
                    page: "1",
                    limit: "10",
                }),
            });
        }
    }

    const [firstIndex, setFirstIndex] = useState(0);

    useEffect(() => {
        if (!hasBooks) {
            (async () => {
                setBooks([]);
                
                const booksData: {
                    books: Book[];
                    totalBooks: number;
                    page: number;
                    limit: number;
                } = await APICaller.getBookList(page, limit);
    
                setBooks(booksData.books);
    
                var totalPage = Math.ceil(booksData.totalBooks / booksData.limit);
    
                setPagination({
                    link: pathname,
                    page: booksData.page,
                    limit: booksData.limit,
                    totalPage: totalPage,
                });
    
                setFirstIndex((booksData.page - 1) * booksData.limit);
            })();
        }
    }, [page, limit, hasBooks, pathname]);

    let indexIncrement = 0;
    
    return (
        <div className="container mt-4">
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
                                index={firstIndex + ++indexIncrement}
                                key={b.id}
                                isAdmin={false}
                                hasRequest={false}
                            />
                        ))}
                    </tbody>
                </table>
                {!hasBooks ? <Pagination {...pagination} /> : <></>}
            </div>
        </div>
    );
}
