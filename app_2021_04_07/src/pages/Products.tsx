import axios from "axios";
import { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import Product from "../models/Product";

export function Products() {
    const [products, setProducts] = useState<Product[]>([]);

    useEffect(() => {
        (async () => {
            setProducts(await (await axios.get<Product[]>("http://localhost:3001/products").then()).data);
        })();
    }, []);

    return (
        <div className="container">
            <div className="row">
                <table className="table">
                    <thead>
                        <tr>
                            <th className="text-center">Id</th>
                            <th className="text-center">Name</th>
                            <th className="text-center">Image</th>
                            <th className="text-center">Description</th>
                            <th className="text-center">Price</th>
                            <th className="text-center">Quantity</th>
                            <th className="text-center">Actions</th>
                        </tr>
                    </thead>
                    <tbody>
                        {products && products.map(product => 
                            <tr key={product.id}>
                                <th className="text-center" scope="row">{product.id}</th>
                                <td>{product.name}</td>
                                <td><img src={product.image} alt="Product"/></td>
                                <td>{product.description}</td>
                                <td className="text-center">{product.price!.toLocaleString()} VND</td>
                                <td className="text-center">{product.quantity}</td>
                                <td className="text-center">
                                    <Link to={`/product-details/${product.id}`}>Details</Link>
                                </td>
                            </tr>
                        )}
                    </tbody>
                </table>
            </div>
        </div>
    );
}