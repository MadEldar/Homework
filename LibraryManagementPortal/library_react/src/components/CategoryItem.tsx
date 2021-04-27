import { Dispatch, SetStateAction, useState } from "react";
import { Link } from "react-router-dom";
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
            <td>{category.name}</td>
            <td>
                {!category.books || category.books.length === 0 ? (
                    <p>No category was found in this category</p>
                ) : (
                    category.books!.map((b) => <Link to="">{b.title}, </Link>)
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
                    <Link to={StringResource.linkCategory + category.id}>
                        Browse
                    </Link>
                )}
            </td>
        </tr>
    );
}
