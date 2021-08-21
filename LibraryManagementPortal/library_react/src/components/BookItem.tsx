import { Dispatch, SetStateAction, useState } from "react";
import { Link, useHistory } from "react-router-dom";
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
    isAdmin = false,
    hasRequest = false,
    setTargetId,
}: {
    book: Book;
    index: number;
    isAdmin: boolean;
    hasRequest: boolean;
    setTargetId?: Dispatch<SetStateAction<string>>;
}) {
    const history = useHistory();
    const [savedBooksIds, setSavedBookIds] = useState<string[]>(
        getSavedBookIds()
    );

    function reloadStorage() {
        setSavedBookIds(getSavedBookIds());
    }

    const isSaved = savedBooksIds.includes(book.id!);

    return (
        <tr key={index}>
            <th scope="row" className=" text-center">
                {index}
            </th>
            <td>
                <Link
                    to={
                        (isAdmin
                            ? StringResource.linkAdminBookDetails
                            : StringResource.linkBookDetails) + book.id
                    }
                >
                    {book.title}
                </Link>
            </td>
            <td>{book.author}</td>
            <td>
                {!history.location.pathname.includes(
                    StringResource.linkCategoryDetails
                ) ? (
                    <Link
                        to={
                            (isAdmin
                                ? StringResource.linkAdminCategoryDetails
                                : StringResource.linkCategoryDetails) +
                            book.categoryId
                        }
                    >
                        {book.category!.name}
                    </Link>
                ) : (
                    book.category!.name
                )}
            </td>
            <td className=" text-center">
                {isAdmin ? (
                    <>
                        <Link
                            className="btn"
                            to={StringResource.linkAdminBookEdit + `${book.id}`}
                        >
                            Edit
                        </Link>
                        <span> | </span>
                        <button
                            type="button"
                            className="btn"
                            onClick={() => setTargetId!(book.id!)}
                            data-toggle="modal"
                            data-target="#modalDelete"
                        >
                            Delete
                        </button>
                    </>
                ) : (
                    <>
                        {hasRequest ? (
                            <>
                                <label className="form-check-label py-2 px-3">
                                    <input
                                        className="form-check-input"
                                        type="checkbox"
                                        name="ids"
                                        value={book.id}
                                        disabled={!isSaved}
                                    />
                                    Request
                                </label>
                                <span> | </span>
                            </>
                        ) : (
                            <></>
                        )}
                        {!isSaved ? (
                            <button
                                className="btn"
                                type="button"
                                onClick={() => {
                                    saveBookIds(book.id!);
                                    reloadStorage();
                                }}
                            >
                                Add to saved
                            </button>
                        ) : (
                            <button
                                className="btn"
                                type="button"
                                onClick={() => {
                                    removeSavedBookIds(book.id!);
                                    reloadStorage();
                                }}
                            >
                                Remove from saved
                            </button>
                        )}
                    </>
                )}
            </td>
        </tr>
    );
}
