import { useEffect, useState } from "react";
import { useForm } from "react-hook-form";
import Book from "../models/Book";
import Category from "../models/Category";
import APICaller from "../services/APICaller.service";
import StringFormatter from "../helpers/StringFormatter";

export function BookForm({ book, handler }: { book?: Book; handler: any }) {
    const {
        register,
        handleSubmit,
        reset,
        formState: { errors },
    } = useForm();
    const [categories, setCategories] = useState<Category[]>([]);

    useEffect(() => {
        (async () => {
            const response = await APICaller.getAllCategories().then();

            if (response.status === 200) {
                setCategories(response.data);
            }
        })();

        if (book) {
            reset({
                title: book?.title,
                author: book?.author,
                id: book?.id,
            });
        }
    }, [book, reset]);

    // error display move to component
    return (
        <form className="col-6" onSubmit={handleSubmit(handler)}>
            <div className="col-12 form-group">
                <label htmlFor="title">Book title</label>
                <input
                    id="title"
                    type="text"
                    className="form-control"
                    defaultValue={book?.title}
                    {...register("title", {
                        required: StringFormatter.validationForRequired(
                            "book title"
                        ),
                        minLength: {
                            value: 3,
                            message: StringFormatter.validationForMinLength(
                                "book title",
                                3
                            ),
                        },
                    })}
                />
                {errors.title && (
                    <div
                        className={errors.title === "" ? "" : "invalid"}
                        role="alert"
                    >
                        {errors.title.message}
                    </div>
                )}
            </div>
            <div className="col-12 form-group">
                <label htmlFor="author">Book author</label>
                <input
                    id="author"
                    type="text"
                    className="form-control"
                    defaultValue={book?.author}
                    {...register("author", {
                        required: StringFormatter.validationForRequired(
                            "book author's name"
                        ),
                        minLength: {
                            value: 3,
                            message: StringFormatter.validationForMinLength(
                                "book author's name",
                                3
                            ),
                        },
                    })}
                />
                {errors.author && (
                    <div
                        className={errors.author === "" ? "" : "invalid"}
                        role="alert"
                    >
                        {errors.author.message}
                    </div>
                )}
            </div>
            <div className="col-12 form-group">
                <label htmlFor="category">Book category</label>
                <select
                    id="category"
                    className="form-control"
                    defaultValue={book ? book.categoryId : categories[0]?.id}
                    {...register("categoryId", {
                        required: StringFormatter.validationForRequired(
                            "book author's name"
                        ),
                    })}
                >
                    {categories.map((c) => (
                        <option key={c.id} value={c.id}>
                            {c.name}
                        </option>
                    ))}
                </select>
            </div>
            <div className="row justify-content-center col-12 form-group">
                <input type="hidden" value={book?.id} {...register("id")} />
                <button className="btn btn-primary" type="submit">
                    Submit
                </button>
            </div>
        </form>
    );
}
