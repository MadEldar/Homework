import "./App.css";
import { BrowserRouter as Router, Switch, Link, Route } from "react-router-dom";
import Login from "./pages/Login";
import { UserProfile } from "./pages/UserProfile";
import { Alert } from "./components/Alert";
import { useEffect, useState } from "react";
import AlertMessage from "./models/AlertMessage";
import StringResource from "./resources/StringResource";
import { logout } from "./helpers/LocalStorageHelper";
import BookList from "./pages/BookList";
import CategoryList from "./pages/CategoryList";
import AdminBookList from "./pages/Admin/BookList";
import { AdminBookCreate } from "./pages/Admin/BookCreate";
import { AdminBookEdit } from "./pages/Admin/BookEdit";
import "antd/dist/antd.css";
import NewRequest from "./pages/NewRequest";
import AdminCategoryList from "./pages/Admin/CategoryList";
import { AdminCategoryCreate } from "./pages/Admin/CategoryCreate";
import CategoryDetails from "./pages/CategoryDetails";
import BookDetails from "./pages/BookDetails";

function App() {
    const [isAdmin, setIsAdmin] = useState(false);
    const authToken = localStorage.getItem("AuthToken");

    if (
        (!authToken || authToken === "") &&
        window.location.pathname !== StringResource.linkLogin
    ) {
        window.location.href = StringResource.linkLogin;
    } else if (
        authToken &&
        authToken !== "" &&
        window.location.pathname === StringResource.linkLogin
    ) {
        window.location.href = StringResource.linkHome;
    }

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

    const routes: { link: string; page: JSX.Element }[] = [
        {
            link: StringResource.linkUserProfile,
            page: <UserProfile />,
        },
        {
            link: StringResource.linkBook,
            page: <BookList />,
        },
        {
            link: StringResource.linkBookDetails + ":id",
            page: <BookDetails />,
        },
        {
            link: StringResource.linkCategory,
            page: <CategoryList />,
        },
        {
            link: StringResource.linkCategoryDetails + ":id",
            page: <CategoryDetails />,
        },
        {
            link: StringResource.linkNewRequest,
            page: <NewRequest />,
        },
        {
            link: StringResource.linkAdminBookList,
            page: <AdminBookList />,
        },
        {
            link: StringResource.linkAdminBookCreate,
            page: <AdminBookCreate />,
        },
        {
            link: StringResource.linkAdminBookEdit + ":id",
            page: <AdminBookEdit />,
        },
        {
            link: StringResource.linkAdminCategoryCreate,
            page: <AdminCategoryCreate />,
        },
        {
            link: StringResource.linkAdminCategoryList,
            page: <AdminCategoryList />,
        },
    ];

    const [alertMessage, setAlertMessage] = useState<AlertMessage>({
        message: "",
        type: "danger",
    });

    useEffect(() => {
        setIsAdmin(localStorage.getItem(StringResource.admin) !== null);
    }, []);

    return (
        <div className="container">
            <div id="app-root" className="row">
                <Alert
                    message={alertMessage.message}
                    type={alertMessage.type}
                    statusCode={alertMessage.statusCode}
                />
                <Router>
                    <Switch>
                        <Route path={StringResource.linkLogin}>
                            <Login setAlertMessage={setAlertMessage} />
                        </Route>
                        <Route path={StringResource.linkHome}>
                            <nav className="col-12 navbar navbar-expand-lg navbar-light">
                                <Link
                                    className="navbar-brand"
                                    to={StringResource.linkHome}
                                >
                                    L<span>ibrary</span> M<span>anagement</span>
                                    P<span>ortal</span>
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
                                                    window.location.pathname ===
                                                    n.link
                                                        ? " active"
                                                        : ""
                                                }`}
                                            >
                                                <Link
                                                    className="nav-link"
                                                    to={n.link}
                                                >
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
                                                        to="/admin/books"
                                                    >
                                                        Book list
                                                    </Link>
                                                    <Link
                                                        className="dropdown-item"
                                                        to="/admin/categories"
                                                    >
                                                        Category list
                                                    </Link>
                                                    <div className="dropdown-divider"></div>
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
                            <Switch>
                                {routes.map((r) => (
                                    <Route path={r.link} exact>
                                        {r.page}
                                    </Route>
                                ))}
                                <Route path={StringResource.linkLogout}>
                                    {() => logout()}
                                </Route>
                            </Switch>
                        </Route>
                    </Switch>
                </Router>
            </div>
        </div>
    );
}

export default App;
