import axios from "axios";
import { useEffect, useState } from "react";
import { Redirect, useParams } from "react-router";
import { Link } from "react-router-dom";
import Product from "../models/Product";

export function ProductDetails() {
    const {id} = useParams<{id: string}>();
    const [product, setProduct] = useState<Product>({
        id: 0,
        name: "",
        description: "",
        image: "",
        price: 0,
        quantity: 0
    });

    useEffect(() => {
        (async () => {            
            setProduct((await axios.get<Product>(`http://localhost:3001/products/${Number.parseInt(id)}`).then()).data);
        })();
    }, [id])

    if (id === "") {
        return <Redirect to="/products"/>
    }

    return (
        <div className="container">
            <div className="my-4">
                <h1>Product details</h1>
            </div>
            <div className="row mt-2">
                <div className="col-2">
                    <h5><strong>Name</strong></h5>
                </div>
                <div className="col-10">
                    <span>{product.name}</span>
                </div>
            </div>
            <div className="row mt-2">
                <div className="col-2">
                    <h5><strong>Description</strong></h5>
                </div>
                <div className="col-10">
                    <span>{product.description}</span>
                </div>
            </div>
            <div className="row mt-2">
                <div className="col-2">
                    <h5><strong>Image</strong></h5>
                </div>
                <div className="col-10">
                    <img src={product.image} alt="Product"/>
                </div>
            </div>
            <div className="row mt-2">
                <div className="col-2">
                    <h5><strong>Price</strong></h5>
                </div>
                <div className="col-10">
                    <span>{product.price.toLocaleString()} VND</span>
                </div>
            </div>
            <div className="row mt-2">
                <div className="col-2">
                    <h5><strong>Quantity</strong></h5>
                </div>
                <div className="col-10">
                    <span>{product.quantity}</span>
                </div>
            </div>
            <div className="row mt-4">
                <Link className="offset-2" to="/products">Back to product list</Link>
            </div>
        </div>
    )
}