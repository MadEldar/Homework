import { useEffect, useState } from "react";
import { useHistory } from "react-router";
import { useLocation } from "react-router-dom";
import CategoryItem from "../components/CategoryItem";
import Pagination from "../components/Pagination";
import ParamBuilder from "../helpers/ParamBuilder";
import Category from "../models/Category";
import PaginationInfo from "../models/PaginationInfo";
import APICaller from "../services/APICaller.service";

export default function CategoryList() {
    const history = useHistory();
    const pathname = history.location.pathname;
    const [categories, setCategories] = useState<Category[]>([]);
    const [pagination, setPagination] = useState<PaginationInfo>({
        link: pathname,
        page: 1,
        limit: 10,
        totalPage: 1,
    });

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

    const [firstIndex, setFirstIndex] = useState(0);

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

            var totalPage = Math.ceil(categoriesData.totalCategories / categoriesData.limit);

            setPagination({
                link: pathname,
                page: categoriesData.page,
                limit: categoriesData.limit,
                totalPage: totalPage,
            });

            setFirstIndex((categoriesData.page - 1) * limit);
        })();
    }, [page, limit, pathname]);

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
                                index={isNaN(firstIndex) ? 0 : firstIndex + ++indexIncrement}
                                isAdmin={false}
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
