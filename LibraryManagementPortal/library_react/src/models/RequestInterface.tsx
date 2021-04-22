import Book from "./Book";
import User from "./User";

export default interface RequestInterface {
    id: string,
    status: number,
    requestedDate: string,
    updatedDate: string,
    userId: string,
    user?: User,
    books?: Book[]
}