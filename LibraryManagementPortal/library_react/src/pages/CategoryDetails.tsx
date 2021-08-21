import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import Category from "../models/Category";
import APICaller from "../services/APICaller.service";
import BookList from "./BookList";

export default function CategoryDetails() {
    const { id } = useParams<{ id: string }>();
    const [category, setCategory] = useState<Category>({
        id: "",
        name: "",
        books: [],
    });

    useEffect(() => {
        (async () => {
            const response = await APICaller.getCategoryById(id).then();

            if (response.status === 200) {
                setCategory(response.data);
            }
        })();
    }, [id]);

    return (
        <div className="container col-12 mt-5">
            <div className="row">
                <h2 className="col-12 text-center">
                    Category: {category.name}
                </h2>
                {category.books && category.books.length > 0 ? (
                    <BookList initBooks={category.books} />
                ) : (
                    <h4 className="mt-5">No book was found in this category</h4>
                )}
            </div>
        </div>
    );
}
