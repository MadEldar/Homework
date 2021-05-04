import { Dispatch, SetStateAction, useState } from "react";
import { Link, useHistory } from "react-router-dom";
import User from "../models/User";
import StringResource from "../resources/StringResource";

export default function UserItem({
    user,
    index,
    isAdmin = false,
    setTargetId,
}: {
    user: User;
    index: number;
    isAdmin: boolean;
    setTargetId?: Dispatch<SetStateAction<string>>;
}) {
    return (
        <tr key={index}>
            <th scope="row" className=" text-center">
                {index}
            </th>
            <td>
                <Link to={StringResource.linkAdminUserDetails + user.id}>
                    {user.username}
                </Link>
            </td>
            <td>{user.role === 0 ? "User" : "Admin"}</td>
            <td className=" text-center">
                {isAdmin ? (
                    <>
                        <Link
                            className="btn"
                            to={StringResource.linkAdminUserEdit + `${user.id}`}
                        >
                            Edit
                        </Link>
                        <span> | </span>
                        <button
                            type="button"
                            className="btn"
                            onClick={() => setTargetId!(user.id)}
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
