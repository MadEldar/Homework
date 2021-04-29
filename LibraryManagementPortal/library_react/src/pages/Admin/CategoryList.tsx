import { useEffect, useState } from "react";
import { useHistory } from "react-router";
import { Link, useLocation } from "react-router-dom";
import CategoryItem from "../../components/CategoryItem";
import ConfirmModal from "../../components/ConfirmModal";
import Pagination from "../../components/Pagination";
import ParamBuilder from "../../helpers/ParamBuilder";
import Category from "../../models/Category";
import PaginationInfo from "../../models/PaginationInfo";
import StringResource from "../../resources/StringResource";
import APICaller from "../../services/APICaller.service";

export default function AdminCategoryList() {
    const history = useHistory();
    const pathname = history.location.pathname;
    const [categories, setCategories] = useState<Category[]>([]);
    const [pagination, setPagination] = useState<PaginationInfo>({
        link: pathname,
        page: 1,
        limit: 10,
        totalPage: 1,
    });
    const [deleteTargetId, setDeleteTargetId] = useState("");

    function deleteCategory() {
        (async () => {
            const result = await APICaller.deleteCategory(
                deleteTargetId
            ).then();

            if (result.statusCode === 200) {
                setCategories(
                    categories.filter((b) => b.id !== deleteTargetId)
                );
            }
        })();
    }

    let query = new URLSearchParams(useLocation().search);

    if (!query.get("page") || !query.get("limit")) {
        history.replace({
            pathname: pathname,
            search: ParamBuilder({
                page: "1",
                limit: "10",
            }),
        });
    }

    const page = Number.parseInt(query.get("page")!) || 1;
    const limit = Number.parseInt(query.get("limit")!) || 10;

    useEffect(() => {
        (async () => {
            setCategories([]);

            const categoriesData: {
                categories: Category[];
                totalCategories: number;
                page: number;
                limit: number;
            } = await APICaller.getCategoryList(page, limit);

            setCategories(categoriesData.categories);

            var totalPage = Math.ceil(
                categoriesData.totalCategories / categoriesData.limit
            );

            setPagination({
                link: pathname,
                page: categoriesData.page,
                limit: categoriesData.limit,
                totalPage: totalPage,
            });
        })();
    }, [page, limit, pathname]);

    let indexIncrement = (page - 1) * limit;

    return (
        <>
            <div className="container mt-5">
                <div className="row">
                    <h2 className="col-8 offset-2 text-center">
                        Category List
                    </h2>
                    <Link
                        to={StringResource.linkAdminCategoryCreate}
                        className="col-2 btn btn-primary"
                    >
                        Create new category
                    </Link>
                    <table className="table table-striped mt-5">
                        <thead>
                            <tr>
                                <th scope="col">#</th>
                                <th scope="col">Name</th>
                                <th scope="col">Books</th>
                                <th scope="col">Action</th>
                            </tr>
                        </thead>
                        <tbody>
                            {categories.map((b) => (
                                <CategoryItem
                                    category={b}
                                    index={++indexIncrement}
                                    key={b.id}
                                    isAdmin={true}
                                    setTargetId={setDeleteTargetId}
                                />
                            ))}
                        </tbody>
                    </table>
                    <Pagination {...pagination} />
                </div>
            </div>

            <ConfirmModal
                id="modalDelete"
                action="delete"
                confirmMessage="Are you sure you want to delete this category?"
                title="Delete category"
                handleConfirm={deleteCategory}
                targetId={deleteTargetId}
            />
        </>
    );
}
