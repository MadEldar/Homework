import { Link } from "react-router-dom";
import PaginationInfo from "../models/PaginationInfo";

export default function Pagination({
    link,
    page,
    limit,
    totalPage,
    className
}: PaginationInfo) {
    var indexer = [];

    for (let i = 1; i <= totalPage; i++) {
        indexer.push(i);
    }

    const isFirstPage = page - 1 === 0;
    const isLastPage = page === totalPage;

    return (
        <div className={className ?? ""}>
            <nav aria-label="Page navigation example">
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
        </div>
    );
}
