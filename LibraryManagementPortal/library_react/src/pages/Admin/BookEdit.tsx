import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { BookForm } from "../../components/BookForm";
import Book from "../../models/Book";
import APICaller from "../../services/APICaller.service";

export default function AdminBookEdit() {
    const { id } = useParams<{ id: string }>();
    const [book, setBook] = useState<Book>();

    useEffect(() => {
        (async () => {
            const book = await APICaller.getBookById(id).then();

            setBook(book);
        })();
    }, [id]);

    function submitEdit(data: {
        id: string;
        title: string;
        author: string;
        category: string;
    }) {
        let formData = new FormData();

        console.log(data);

        formData.append("id", data.id);
        formData.append("title", data.title);
        formData.append("author", data.author);
        formData.append("categoryId", data.category);

        // (async () => {
        //     const response = await APICaller.putBook(formData).then();

        //     if (response.data.statusCode === 201) {
        //         const bookId = response.data.headers.find(
        //             (h: { key: string; value: string[] }) => h.key === "BookId"
        //         ).value[0];

        //         history.push(
        //             StringResource.linkAdminBookDetails + `/${bookId}`
        //         );
        //     }
        // })();
    }

    return (
        <>
            <div className="container center-aligned">
                <div className="row col-12">
                    <BookForm book={book} handler={submitEdit} />
                </div>
            </div>
        </>
    );
}
