import { useHistory } from "react-router";
import { CategoryForm } from "../../components/CategoryForm";
import Category from "../../models/Category";
import StringResource from "../../resources/StringResource";
import APICaller from "../../services/APICaller.service";

export default function AdminCategoryCreate() {
    const history = useHistory();

    function submitCreate(data: {
        name: string;
    }) {
        (async () => {
            const response = await APICaller.postCategory(data.name).then();

            if (response.status === 201) {
                const category: Category = response.data;

                history.push(StringResource.linkAdminCategoryDetails + category.id);
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
