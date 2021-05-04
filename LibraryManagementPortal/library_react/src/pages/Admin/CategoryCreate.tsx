import { useHistory } from "react-router";
import { CategoryForm } from "../../components/CategoryForm";
import StringResource from "../../resources/StringResource";
import APICaller from "../../services/APICaller.service";

export default function AdminCategoryCreate() {
    const history = useHistory();

    function submitCreate(data: {
        name: string;
    }) {
        let formData = new FormData();
        
        formData.append("name", data.name);

        (async () => {
            const response = await APICaller.postCategory(formData).then();

            if (response.statusCode === 201) {
                // TODO: fix api header to send book id
                // const bookId = response.headers.find(
                //     (h: { key: string; value: string[] }) => h.key === "CategoryId"
                // ).value[0];

                const reasonPhrase: string = response.reasonPhrase;

                history.push(
                    StringResource.linkCategoryDetails + `${reasonPhrase.slice(reasonPhrase.indexOf(": ") + 2)}`
                );
            }
        })();
    }

    return (
        <div className="container">
            <div className="row justify-content-center">
                <CategoryForm handler={submitCreate} />
            </div>
        </div>
    );
}
