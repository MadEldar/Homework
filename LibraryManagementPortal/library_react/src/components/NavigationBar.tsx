import { Link, useHistory } from "react-router-dom";
import StringResource from "../resources/StringResource";

export default function NavigationBar({ isAdmin }: { isAdmin: boolean }) {
    const history = useHistory();
    const navLinks: { link: string; name: string }[] = [
        {
            link: StringResource.linkUserProfile,
            name: "User profile",
        },
        {
            link: StringResource.linkBook,
            name: "Book list",
        },
        {
            link: StringResource.linkCategory,
            name: "Category list",
        },
        {
            link: StringResource.linkNewRequest,
            name: "Saved",
        },
        {
            link: StringResource.linkLogout,
            name: "Logout",
        },
    ];

    return (
        <nav className="col-12 navbar navbar-expand-lg navbar-light">
            <Link className="navbar-brand" to={StringResource.linkHome}>
                L<span>ibrary</span> M<span>anagement</span>P<span>ortal</span>
            </Link>
            <div
                className="collapse navbar-collapse"
                id="navbarSupportedContent"
            >
                <ul className="navbar-nav mr-auto">
                    {navLinks.map((n) => (
                        <li
                            key={n.link}
                            className={`nav-item${
                                history.location.pathname === n.link
                                    ? " active"
                                    : ""
                            }`}
                        >
                            <Link className="nav-link" to={n.link}>
                                {n.name}
                            </Link>
                        </li>
                    ))}

                    {isAdmin ? (
                        <li className="nav-item dropdown">
                            <button
                                className="btn nav-link dropdown-toggle"
                                id="adminNavigation"
                                data-toggle="dropdown"
                                aria-haspopup="true"
                                aria-expanded="false"
                            >
                                Admin
                            </button>
                            <div
                                className="dropdown-menu"
                                aria-labelledby="adminNavigation"
                            >
                                <Link
                                    className="dropdown-item"
                                    to={StringResource.linkAdminBookList}
                                >
                                    Book list
                                </Link>
                                <Link
                                    className="dropdown-item"
                                    to={StringResource.linkAdminCategoryList}
                                >
                                    Category list
                                </Link>
                                <Link
                                    className="dropdown-item"
                                    to={StringResource.linkAdminUserList}
                                >
                                    User list
                                </Link>
                                <div className="dropdown-divider"></div>
                                <Link
                                    className="dropdown-item"
                                    to={StringResource.linkAdminRequestList}
                                >
                                    Request list
                                </Link>
                            </div>
                        </li>
                    ) : (
                        <></>
                    )}
                </ul>
                {/* TODO: search function
            <form className="form-inline my-2 my-lg-0">
                <input
                    className="form-control mr-sm-2"
                    type="search"
                    placeholder="Search"
                    aria-label="Search"
                />
                <button
                    className="btn btn-outline-success my-2 my-sm-0"
                    type="submit"
                >
                    Search
                </button>
            </form> */}
            </div>
        </nav>
    );
}
