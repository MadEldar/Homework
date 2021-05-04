import { Link, useHistory } from "react-router-dom";
import PaginationInfo from "../models/PaginationInfo";

export default function Pagination({
    link,
    page,
    limit,
    totalPage,
    className
}: PaginationInfo) {
    const history = useHistory();
    var indexer = [];

    for (let i = 1; i <= totalPage; i++) {
        indexer.push(i);
    }

    const isFirstPage = page - 1 === 0;
    const isLastPage = page === totalPage;

    const currentParams = history.location.search;    
    const params = new URLSearchParams(currentParams);

    function selectLimit(e: any) {
        const newLimit = e.target.value || 10;
        params.set("limit", newLimit);

        history.push({
            pathname: link,
            search: params.toString()
        })
    }

    return (
        <div className={(className ?? "") + " row"}>
            <nav aria-label="Page navigation">
                <ul className="pagination justify-content-end">
                    <li
                        className={`page-item${isFirstPage ? " disabled" : ""}`}
                    >
                        <Link
                            className="page-link"
                            to={link + `?page=${page - 1}&limit=${limit}`}
                            aria-disabled={isFirstPage ? true : false}
                        >
                            Previous
                        </Link>
                    </li>
                    {indexer.map((i) => (
                        <li
                            className={`page-item${
                                i === page ? " disabled" : ""
                            }`}
                            key={i}
                        >
                            <Link
                                className="page-link"
                                to={link + `?page=${i}&limit=${limit}`}
                            >
                                {i}
                            </Link>
                        </li>
                    ))}
                    <li className={`page-item${isLastPage ? " disabled" : ""}`}>
                        <Link
                            className="page-link"
                            to={link + `?page=${page + 1}&limit=${limit}`}
                            aria-disabled={isLastPage ? true : false}
                        >
                            Next
                        </Link>
                    </li>
                </ul>
            </nav>
            <div className="form-group ml-3">
                <select name="limit" className="form-control" value={params.get("limit") || 10} onChange={(e) => selectLimit(e)}>
                    <option value="1">1</option>
                    <option value="3">3</option>
                    <option value="5">5</option>
                    <option value="10">10</option>
                    <option value="15">15</option>
                    <option value="15">20</option>
                    <option value="15">25</option>
                </select>
            </div>
        </div>
    );
}
