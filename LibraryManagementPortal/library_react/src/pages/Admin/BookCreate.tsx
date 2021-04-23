import { useHistory } from "react-router";
import { BookFrom } from "../../components/BookForm";
import StringResource from "../../resources/StringResource";
import APICaller from "../../services/APICaller.service";

export function AdminBookCreate() {
    const history = useHistory();

    function submitCreate(data: {
        id?: string;
        title: string;
        author: string;
        category: string;
    }) {
        let formData = new FormData();
        
        formData.append("title", data.title);
        formData.append("author", data.author);
        formData.append("categoryId", data.category);

        (async () => {
            const response = await APICaller.postBook(formData).then();

            if (response.data.statusCode === 201) {
                const bookId = response.data.headers.find(
                    (h: { key: string; value: string[] }) => h.key === "BookId"
                ).value[0];

                history.push(
                    StringResource.linkAdminBookDetails + `/${bookId}`
                );
            }
        })();
    }

    return (
        <div className="container center-aligned">
            <div className="row">
                <BookFrom handler={submitCreate} />
            </div>
        </div>
    );
}
