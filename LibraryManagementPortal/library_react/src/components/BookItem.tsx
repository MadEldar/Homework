import { Link } from "react-router-dom";
import Book from "../models/Book";
import StringResource from "../resources/StringResource";

export default function BookItem({
    book,
    index,
    isAdmin,
}: {
    book: Book;
    index: number;
    isAdmin: boolean;
}) {
    return (
        <tr key={index}>
            <th scope="row">{index}</th>
            <td>{book.title}</td>
            <td>{book.author}</td>
            <td>{book.category!.name}</td>
            <td>
                {/* {isAdmin ?? */}
                    <Link to={StringResource.linkAdminBookEdit + `/${book.id}`}>
                        Edit
                    </Link>
                    <span> | </span>
                    <Link to={StringResource.linkAdminBookDelete + `/${book.id}`}>
                        Delete
                    </Link>
                {/* } */}
            </td>
        </tr>
    );
}
