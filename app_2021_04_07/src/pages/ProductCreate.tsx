import "../App.css";
import { Link, Redirect } from "react-router-dom";
import { ImageUrlRegex } from "../RegexStrings";
import { useForm } from "react-hook-form";
import axios from "axios";

export function ProductCreate() {
    const {
        register,
        handleSubmit,
        formState: { errors },
    } = useForm();

    function onSubmit(data: any) {
        axios
            .post("http://localhost:3001/products", data)
            .then(res => {
                if (res.status === 201) {
                    return <Redirect to="/products" />
                }
            });
    }

    return (
        <div className="container">
            <div className="row justify-content-center">
                <div className="col-12">
                    <h3 className="text-center">Create new product</h3>
                </div>
                <form className="col-6" onSubmit={handleSubmit(onSubmit)}>
                    <div className="col-12 mt-3">
                        <label htmlFor="name">Product name</label>
                        <input
                            type="text"
                            id="name"
                            className={`form-control`}
                            {...register("name", {
                                required: "Product name is required",
                                minLength: {
                                    value: 3,
                                    message:
                                        "Product name length must be longer than 2 character",
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

                    <div className="col-12 mt-3">
                        <label htmlFor="image">Product image</label>
                        <input
                            type="text"
                            id="image"
                            className={`form-control`}
                            {...register("image", {
                                required: "Product image is required",
                                pattern: {
                                    value: ImageUrlRegex,
                                    message: "This is not a valud image url.",
                                },
                            })}
                        />
                        {errors.image && (
                            <div
                                className={errors.image === "" ? "" : "invalid"}
                                role="alert"
                            >
                                {errors.image.message}
                            </div>
                        )}
                    </div>

                    <div className="col-12 mt-3">
                        <label htmlFor="price">Product price</label>
                        <input
                            type="number"
                            id="price"
                            className={`form-control`}
                            {...register("price", {
                                required: "Product price is required",
                                valueAsNumber: true,
                                min: {
                                    value: 1,
                                    message:
                                        "Product price must be larger than 0",
                                },
                            })}
                        />
                        {errors.price && (
                            <div
                                className={errors.price === "" ? "" : "invalid"}
                                role="alert"
                            >
                                {errors.price.message}
                            </div>
                        )}
                    </div>

                    <div className="col-12 mt-3">
                        <label htmlFor="description">Product description</label>
                        <textarea
                            id="description"
                            rows={4}
                            className={`form-control`}
                            {...register("description", {
                                required: "Product description is required",
                                minLength: {
                                    value: 3,
                                    message:
                                        "Product description length must be longer than 2 character",
                                },
                            })}
                        />
                        {errors.description && (
                            <div
                                className={
                                    errors.description === "" ? "" : "invalid"
                                }
                                role="alert"
                            >
                                {errors.description.message}
                            </div>
                        )}
                    </div>

                    <div className="col-12 mt-3">
                        <label htmlFor="quantity">Product quantity</label>
                        <input
                            type="number"
                            id="quantity"
                            className={`form-control`}
                            {...register("quantity", {
                                required: "Product quantity is required",
                                valueAsNumber: true,
                                min: {
                                    value: 1,
                                    message:
                                        "Product price must be larger than 0",
                                },
                            })}
                        />
                        {errors.quantity && (
                            <div
                                className={
                                    errors.quantity === "" ? "" : "invalid"
                                }
                                role="alert"
                            >
                                {errors.quantity.message}
                            </div>
                        )}
                    </div>

                    <div className="container col-12 mt-3">
                        <div className="row justify-content-center">
                            <button className="btn btn-primary" type="submit">
                                Submit
                            </button>
                            <Link
                                className="btn btn-outline-primary ml-2"
                                to="/home"
                            >
                                Return to home
                            </Link>
                        </div>
                    </div>
                </form>
            </div>
        </div>
    );
}
