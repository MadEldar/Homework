import Book from "../models/Book";

export default function BookItem({ book, index, } : { book: Book; index: number; }) {
    return (
        <tr>
            <th scope="row">{index}</th>
            <td>{book.title}</td>
            <td>{book.author}</td>
            <td>{book.category!.name}</td>
        </tr>
    );
}
