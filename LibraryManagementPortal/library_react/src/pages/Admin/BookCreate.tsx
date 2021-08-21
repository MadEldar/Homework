import { useHistory } from "react-router";
import { BookForm } from "../../components/BookForm";
import Book from "../../models/Book";
import StringResource from "../../resources/StringResource";
import APICaller from "../../services/APICaller.service";

export default function AdminBookCreate() {
    const history = useHistory();

    function submitCreate(data: Book) {
        (async () => {
            const response = await APICaller.postBook(data).then();

            if (response.status === 201) {
                const book: Book = response.data;

                history.push(StringResource.linkAdminBookDetails + book.id);
            }
        })();
    }

    return (
        <div className="container center-aligned">
            <div className="row">
                <BookForm handler={submitCreate} />
            </div>
        </div>
    );
}
