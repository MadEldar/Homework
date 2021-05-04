import { Dispatch, SetStateAction } from "react";
import { Link } from "react-router-dom";
import Book from "../models/Book";
import Category from "../models/Category";
import StringResource from "../resources/StringResource";

export default function CategoryItem({
    category,
    index,
    isAdmin = false,
    setTargetId,
}: {
    category: Category;
    index: number;
    isAdmin: boolean;
    setTargetId?: Dispatch<SetStateAction<string>>;
}) {
    return (
        <tr key={category.id}>
            <th scope="row">{isNaN(index) ? 1 : index}</th>
            <td>
                <Link
                    to={
                        (isAdmin
                            ? StringResource.linkAdminCategoryDetails
                            : StringResource.linkCategoryDetails) + category.id
                    }
                >
                    {category.name}
                </Link>
            </td>
            <td>
                {!category.books || category.books.length === 0 ? (
                    <p>No book was found in this category</p>
                ) : (
                    category.books!.map((b: Book) => (
                        <Link
                            to={
                                (isAdmin
                                    ? StringResource.linkAdminBookDetails
                                    : StringResource.linkBookDetails) + b.id
                            }
                        >
                            {b.title},{" "}
                        </Link>
                    ))
                )}
            </td>
            <td>
                {isAdmin ? (
                    <>
                        <Link
                            className="btn"
                            to={
                                StringResource.linkAdminCategoryEdit +
                                category.id
                            }
                        >
                            Edit
                        </Link>
                        <span> | </span>
                        <button
                            type="button"
                            className="btn"
                            onClick={() => setTargetId!(category.id)}
                            data-toggle="modal"
                            data-target="#modalDelete"
                        >
                            Delete
                        </button>
                    </>
                ) : (
                    <></>
                )}
            </td>
        </tr>
    );
}
