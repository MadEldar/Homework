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
        <tr>
            <th scope="row">{index}</th>
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
