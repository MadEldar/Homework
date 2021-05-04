import { useHistory } from "react-router";
import { BookForm } from "../../components/BookForm";
import StringResource from "../../resources/StringResource";
import APICaller from "../../services/APICaller.service";

export default function AdminBookCreate() {
    const history = useHistory();

    console.log("")

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

            if (response.statusCode === 201) {
                // TODO: fix api header to send book id
                // const bookId = response.headers.find(
                //     (h: { key: string; value: string[] }) => h.key === "BookId"
                // ).value[0];

                const reasonPhrase: string = response.reasonPhrase;

                history.push(
                    StringResource.linkBookDetails + `${reasonPhrase.slice(reasonPhrase.indexOf(": ") + 2)}`
                );
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
