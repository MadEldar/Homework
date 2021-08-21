import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { CategoryForm } from "../../components/CategoryForm";
import Category from "../../models/Category";
import APICaller from "../../services/APICaller.service";

export function AdminCategoryEdit() {
    const { id } = useParams<{ id: string }>();
    const [category, setCategory] = useState<Category>();

    useEffect(() => {
        (async () => {
            const category: Category = await APICaller.getCategoryById(id).then();

            setCategory(category);
        })();
    }, [id]);

    function submitEdit(data: {
        id: string;
        title: string;
        author: string;
        category: string;
    }) {
        let formData = new FormData();

        formData.append("id", data.id);
        formData.append("title", data.title);
        formData.append("author", data.author);
        formData.append("categoryId", data.category);

        // (async () => {
        //     const response = await APICaller.putCategory(formData).then();

        //     if (response.data.statusCode === 201) {
        //         const categoryId = response.data.headers.find(
        //             (h: { key: string; value: string[] }) => h.key === "CategoryId"
        //         ).value[0];

        //         history.push(
        //             StringResource.linkAdminCategoryDetails + `/${categoryId}`
        //         );
        //     }
        // })();
    }

    return (
        <>
            <div className="container center-aligned">
                <div className="row col-12">
                    <CategoryForm category={category} handler={submitEdit} />
                </div>
            </div>
        </>
    );
}
