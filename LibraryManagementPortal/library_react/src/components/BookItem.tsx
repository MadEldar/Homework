import { Dispatch, SetStateAction, useState } from "react";
import { Link } from "react-router-dom";
import {
    saveBookIds,
    getSavedBookIds,
    removeSavedBookIds,
} from "../helpers/LocalStorageHelper";
import Book from "../models/Book";
import StringResource from "../resources/StringResource";

export default function BookItem({
    book,
    index,
    isAdmin,
    setTargetId,
}: {
    book: Book;
    index: number;
    isAdmin: boolean;
    setTargetId?: Dispatch<SetStateAction<string>>;
}) {
    const [savedBooksIds, setSavedBookIds] = useState<string[]>(
        getSavedBookIds()
    );

    function reloadStorage() {
        setSavedBookIds(getSavedBookIds());
    }

    const isSaved = savedBooksIds.includes(book.id);

    return (
        <tr key={index}>
            <th scope="row" className=" text-center">
                {index}
            </th>
            <td>{book.title}</td>
            <td>{book.author}</td>
            <td>{book.category!.name}</td>
            <td className=" text-center">
                {isAdmin ? (
                    <>
                        <Link
                            className="btn"
                            to={
                                StringResource.linkAdminBookEdit + `/${book.id}`
                            }
                        >
                            Edit
                        </Link>
                        <span> | </span>
                        <button
                            type="button"
                            className="btn"
                            onClick={() => setTargetId!(book.id)}
                            data-toggle="modal"
                            data-target="#modalDelete"
                        >
                            Delete
                        </button>
                    </>
                ) : (
                    <>
                        <div className="form-group">
                            <label className="form-check-label">
                                <input
                                    className="form-check-input"
                                    type="checkbox"
                                    name="ids"
                                    value={book.id}
                                    disabled={!isSaved}
                                />
                                Request
                            </label>
                        </div>
                        {!isSaved ? (
                            <a
                                type="button"
                                onClick={() => {
                                    saveBookIds(book.id);
                                    reloadStorage();
                                }}
                            >
                                Add to saved
                            </a>
                        ) : (
                            <a
                                type="button"
                                onClick={() => {
                                    removeSavedBookIds(book.id);
                                    reloadStorage();
                                }}
                            >
                                Remove from saved
                            </a>
                        )}
                    </>
                )}
            </td>
        </tr>
    );
}
