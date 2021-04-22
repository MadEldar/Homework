import { useEffect, useState } from "react";
import { useHistory } from "react-router";
import { useLocation } from "react-router-dom";
import CategoryItem from "../components/CategoryItem";
import Pagination from "../components/Pagination";
import Category from "../models/Category";
import PaginationInfo from "../models/PaginationInfo";
import StringResource from "../resources/StringResource";
import APICaller from "../services/APICaller.service";

export default function Categories() {
    const history = useHistory();
    const [categories, setCategories] = useState<Category[]>([]);
    const [pagination, setPagination] = useState<PaginationInfo>({
        link: StringResource.linkCategoryList,
        page: 1,
        limit: 10,
        totalPage: 1,
    });

    let query = new URLSearchParams(useLocation().search);

    if (!query.get("page")) {
        history.replace({
            pathname: StringResource.linkCategoryList,
            search: "?page=1&limit=10",
        });
    }

    const page = Number.parseInt(query.get("page")!);
    const limit = Number.parseInt(query.get("limit")!);

    const [firstIndex, setFirstIndex] = useState(0);

    useEffect(() => {
        (async () => {
            const categoriesData: {
                categories: Category[];
                totalCategories: number;
                page: number;
                limit: number;
            } = await APICaller.getCategories(
                isNaN(page) ? 1 : page,
                isNaN(limit) ? 10 : limit
            );

            console.log(categoriesData)

            setCategories(categoriesData.categories);

            var totalPage = Math.ceil(categoriesData.totalCategories / categoriesData.limit);

            setPagination({
                link: StringResource.linkCategoryList,
                page: categoriesData.page,
                limit: categoriesData.limit,
                totalPage: totalPage,
            });

            setFirstIndex((categoriesData.page - 1) * limit);
        })();
    }, [page]);

    let indexIncrement = 0;
    return (
        <div className="container mt-5">
            <div className="row">
                <h2 className="w-100 text-center">Category List</h2>
                <table className="table table-striped mt-5">
                    <thead>
                        <tr>
                            <th scope="col">#</th>
                            <th scope="col">Name</th>
                            <th scope="col">Books</th>
                        </tr>
                    </thead>
                    <tbody>
                        {categories.map((c) => (
                            <CategoryItem
                                category={c}
                                index={firstIndex + ++indexIncrement}
                                key={c.id}
                            />
                        ))}
                    </tbody>
                </table>
                <Pagination {...pagination} />
            </div>
        </div>
    );
}
