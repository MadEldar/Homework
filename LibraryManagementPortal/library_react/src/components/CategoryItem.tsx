import { Link } from "react-router-dom";
import Category from "../models/Category";

export default function CategoryItem({
    category,
    index,
}: {
    category: Category;
    index: number;
}) {
    return (
        <tr key={index}>
            <th scope="row">{isNaN(index) ? 1 : index}</th>
            <td>{category.name}</td>
            <td>
                {!category.books || category.books.length === 0 ? (
                    <p>No book was found in this category</p>
                ) : (
                    category.books!.map((b) => <Link to="">{b.title}, </Link>)
                )}
            </td>
        </tr>
    );
}
