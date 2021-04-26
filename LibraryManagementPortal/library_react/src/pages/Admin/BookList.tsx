import { useEffect, useState } from "react";
import { useHistory } from "react-router";
import { Link, useLocation } from "react-router-dom";
import BookItem from "../../components/BookItem";
import ConfirmModal from "../../components/ConfirmModal";
import Pagination from "../../components/Pagination";
import Book from "../../models/Book";
import PaginationInfo from "../../models/PaginationInfo";
import StringResource from "../../resources/StringResource";
import APICaller from "../../services/APICaller.service";

export default function AdminBookList() {
    const history = useHistory();
    const [books, setBooks] = useState<Book[]>([]);
    const [pagination, setPagination] = useState<PaginationInfo>({
        link: StringResource.linkAdminBookList,
        page: 1,
        limit: 10,
        totalPage: 1,
    });
    const [deleteTargetId, setDeleteTargetId] = useState("");

    function deleteBook() {
        (async() => {
            const result = await APICaller.deleteBook(deleteTargetId).then();

            if (result.statusCode === 200) {
                setBooks(books.filter(b => b.id !== deleteTargetId))
            }
        })();
    }

    let query = new URLSearchParams(useLocation().search);

    if (!query.get("page") && !query.get("limit")) {
        history.replace({
            pathname: StringResource.linkAdminBookList,
            search: "?page=1&limit=10",
        });
    }

    const page = Number.parseInt(query.get("page")!);
    const limit = Number.parseInt(query.get("limit")!);

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
                link: StringResource.linkAdminBookList,
                page: booksData.page,
                limit: booksData.limit,
                totalPage: totalPage,
            });
        })();
    }, [page, limit]);

    let indexIncrement = (page - 1) * limit;

    return (
        <>
            <div className="container mt-5">
                <div className="row">
                    <h2 className="col-8 offset-2 text-center">Book List</h2>
                    <Link
                        to={StringResource.linkAdminBookCreate}
                        className="col-2 btn btn-primary"
                    >
                        Create new book
                    </Link>
                    <table className="table table-striped mt-5">
                        <thead>
                            <tr>
                                <th scope="col">#</th>
                                <th scope="col">Title</th>
                                <th scope="col">Author</th>
                                <th scope="col">Category</th>
                                <th scope="col">Action</th>
                            </tr>
                        </thead>
                        <tbody>
                            {books.map((b) => (
                                <BookItem
                                    book={b}
                                    index={
                                        // isNaN(firstIndex)
                                        //     ? 0
                                        //     : firstIndex + 
                                            ++indexIncrement
                                    }
                                    key={b.id}
                                    isAdmin={true}
                                    hasRequest={false}
                                    setTargetId={setDeleteTargetId}
                                />
                            ))}
                        </tbody>
                    </table>
                    <Pagination {...pagination} />
                </div>
            </div>

            <ConfirmModal
                id="modalDelete"
                action="delete"
                confirmMessage="Are you sure you want to delete this book?"
                title="Delete book"
                handleConfirm={deleteBook}
                targetId={deleteTargetId}
            />
        </>
    );
}
