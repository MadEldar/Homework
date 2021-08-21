import { useEffect, useState } from "react";
import { Link, useParams } from "react-router-dom";
import Book from "../../models/Book";
import StringResource from "../../resources/StringResource";
import APICaller from "../../services/APICaller.service";
import AdminRequestList from "./RequestList";

export default function AdminBookDetails() {
    const { id } = useParams<{ id: string }>();
    const [book, setBook] = useState<Book>({
        id: "",
        title: "",
        author: "",
        categoryId: "",
    });

    useEffect(() => {
        (async () => {
            const response = await APICaller.getBookById(id).then();
            if (response.status === 200) {
                setBook(response.data);
            }
        })();
    }, [id]);

    return (
        <div className="container col-12 mt-5">
            <div className="row">
                <h2 className="col-12 text-center">Book details</h2>
                <div className="row col-12 mt-4">
                    <div className="row col-6 mt-3">
                        <div className="col-4">
                            <h5>Title:</h5>
                        </div>
                        <div className="col-8">
                            <p>{book.title}</p>
                        </div>
                    </div>
                    <div className="row col-6 mt-3">
                        <div className="col-4">
                            <h5>Author:</h5>
                        </div>
                        <div className="col-8">
                            <p>{book.author}</p>
                        </div>
                    </div>
                    <div className="row col-6 mt-3">
                        <div className="col-4">
                            <h5>Category:</h5>
                        </div>
                        <div className="col-8">
                            <Link
                                to={
                                    StringResource.linkAdminCategoryDetails +
                                    book.categoryId
                                }
                            >
                                {book.category?.name}
                            </Link>
                        </div>
                    </div>
                </div>

                {book.requests && book.requests.length > 0 ? (
                    <AdminRequestList initRequests={book.requests} />
                ) : (
                    <></>
                )}
            </div>
        </div>
    );
}
