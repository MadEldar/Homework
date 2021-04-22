import Category from "./Category";
import RequestInterface from "./RequestInterface";

export default interface Book {
    id: string,
    title: string,
    author: string,
    categoryId: string,
    category?: Category
    requests?: RequestInterface[]
}