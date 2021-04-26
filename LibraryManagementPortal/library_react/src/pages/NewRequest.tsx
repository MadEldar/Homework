import { useEffect, useState } from "react";
import BookItem from "../components/BookItem";
import { getSavedBookIds } from "../helpers/LocalStorageHelper";
import Book from "../models/Book";
import APICaller from "../services/APICaller.service";

export default function NewRequest() {
    const [requestBooks, setRequestBooks] = useState<Book[]>([]);

    useEffect(() => {
        (async () => {
            const bookIds = getSavedBookIds();

            if (bookIds.length === 0) {
                setRequestBooks([]);
            } else {
                const response = await APICaller.getBooksByIds(bookIds).then();

                setRequestBooks(response);
            }
        })();
    }, []);

    let indexIncrement = 0;

    async function sendBookRequest(e: any) {
        e.preventDefault();
        const formData = new FormData(e.target);

        // const ids = formData.getAll("ids").map(id => id);

        let ids: string[] = [];

        formData.getAll("ids").map(id => id).forEach(id => {
            ids.push(id.toString());
        });

        const result = await APICaller.postRequest(ids).then();

        console.log(result);
    }

    return (
        <div className="container mt-5">
            <form id="requestForm" className="row" onSubmit={sendBookRequest}>
                <h2 className="w-100 text-center">Book List</h2>
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
                                />
                            ))
                        ) : (
                            <p className="text-center">There is no book saved in your request</p>
                        )}
                    </tbody>
                </table>
                <div className="col-12">
                <button className="btn btn-primary float-right mr-2">Request books</button>
                </div>
            </form>
        </div>
    );
}
