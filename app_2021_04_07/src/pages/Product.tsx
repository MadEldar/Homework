import "../App.css";
import { useState } from "react";
import { Link } from "react-router-dom";
import { ImageUrlRegex } from "../RegexStrings";

export function ProductCreate() {
    const [product, setProduct] = useState({
        name: "",
        image: "",
        price: 0,
        description: "",
        quantity: 0,
    });

    const [errors, setErrors] = useState({
        name: "",
        image: "",
        description: "",
        price: "",
        quantity: ""
    });

    function handleFieldChange(e: any) {
        const target = e.target.name;
        const value = e.target.value;
        setProduct((pre) => {
            return { ...pre, [target]: value };
        });
        setErrorMessage(target, "");
    }

    function handleSubmit(e: any) {
        e.preventDefault();
        const {name, image, price, description, quantity} = product;
        if (name === "") setErrorMessage("name", "Product name must not be empty");
        else if (name.length <= 2) setErrorMessage("name", "Product name must be longer than 2 characters");

        if (image === "") setErrorMessage("image", "Product image must not be empty");
        else if (!image.match(RegExp(ImageUrlRegex))) setErrorMessage("image", "Product image link is not valid");

        if (description === "") setErrorMessage("description", "Product description must not be empty");

        if (price <= 0) setErrorMessage("price", "Product price must not be less than 0");

        if (quantity <= 0) setErrorMessage("quantity", "Product quantity must not be less than 0");
    }

    function setErrorMessage(field: string, message: string) {
        setErrors(pre => { return {...pre, [field]: message}})
    }

    return (
        <div className="container">
            <div className="row justify-content-center">
                <div className="col-12">
                    <h3 className="text-center">Create new product</h3>
                </div>
                <form className="col-6" onSubmit={handleSubmit}>
                    <div className="col-12 mt-5">
                        <label htmlFor="name">Product name</label>
                        <input
                            type="text"
                            name="name"
                            id="name"
                            className={`form-control${errors.name === "" ? "" : " invalid"}`}
                            value={product.name}
                            onChange={handleFieldChange}
                        />
                        {errors.name && (
                            <div className={errors.name === "" ? "" : "invalid"}>
                                {errors.name}
                            </div>
                        )}
                    </div>

                    <div className="col-12 mt-5">
                        <label htmlFor="image">Product image</label>
                        <input
                            type="text"
                            name="image"
                            id="image"
                            className={`form-control${errors.image === "" ? "" : " invalid"}`}
                            value={product.image}
                            onChange={handleFieldChange}
                        />
                        {errors.image && (
                            <div className={errors.image === "" ? "" : "invalid"}>
                                {errors.image}
                            </div>
                        )}
                    </div>

                    <div className="col-12 mt-5">
                        <label htmlFor="price">Product price</label>
                        <input
                            type="number"
                            name="price"
                            id="price"
                            className={`form-control${errors.price === "" ? "" : " invalid"}`}
                            value={product.price}
                            onChange={handleFieldChange}
                        />
                        {errors.price && (
                            <div className={errors.price === "" ? "" : "invalid"}>
                                {errors.price}
                            </div>
                        )}
                    </div>

                    <div className="col-12 mt-5">
                        <label htmlFor="description">Product description</label>
                        <textarea
                            id="description"
                            rows={4}
                            className={`form-control${errors.description === "" ? "" : " invalid"}`}
                            name="description"
                            value={product.description}
                            onChange={handleFieldChange}
                        />
                        {errors.description && (
                            <div className={errors.description === "" ? "" : "invalid"}>
                                {errors.description}
                            </div>
                        )}
                    </div>

                    <div className="col-12 mt-5">
                        <label htmlFor="quantity">Product quantity</label>
                        <input
                            type="number"
                            name="quantity"
                            id="quantity"
                            className={`form-control${errors.quantity === "" ? "" : " invalid"}`}
                            value={product.quantity}
                            onChange={handleFieldChange}
                        />
                        {errors.quantity && (
                            <div className={errors.quantity === "" ? "" : "invalid"}>
                                {errors.quantity}
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
