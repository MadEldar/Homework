import RequestInterface from "./RequestInterface";

export default interface User {
    id: string,
    username: string,
    role: number,
    requests?: RequestInterface[]
}