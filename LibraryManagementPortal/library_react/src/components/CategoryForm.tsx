import { useForm } from "react-hook-form";
import Category from "../models/Category";
import StringFormatter from "../helpers/StringFormatter";

export function CategoryForm({
    category,
    handler,
}: {
    category?: Category;
    handler: any;
}) {
    const {
        register,
        handleSubmit,
        formState: { errors },
    } = useForm();

    return (
        <form className="col-6" onSubmit={handleSubmit(handler)}>
            <div className="col-12 form-group">
                <label htmlFor="name">Category name</label>
                <input
                    id="name"
                    type="text"
                    className="form-control"
                    defaultValue={category?.name}
                    {...register("name", {
                        required: StringFormatter.validationForRequired(
                            "category name"
                        ),
                        minLength: {
                            value: 3,
                            message: StringFormatter.validationForMinLength(
                                "category name",
                                3
                            ),
                        },
                    })}
                />
                {errors.name && (
                    <div
                        className={errors.name === "" ? "" : "invalid"}
                        role="alert"
                    >
                        {errors.name.message}
                    </div>
                )}
            </div>
            <div className="row justify-content-center col-12 form-group">
                <input type="hidden" value={category?.id} {...register("id")} />
                <button className="btn btn-primary" type="submit">
                    Submit
                </button>
            </div>
        </form>
    );
}
