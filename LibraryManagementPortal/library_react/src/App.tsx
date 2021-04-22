import "./App.css";
import { BrowserRouter as Router, Switch, Link, Route, useHistory } from "react-router-dom";
import Login from "./pages/Login";
import { UserProfile } from "./pages/UserProfile";
import { Alert } from "./components/Alert";
import { useState } from "react";
import AlertMessage from "./models/AlertMessage";
import StringResource from "./resources/StringResource";
import { logout } from "./helpers/AuthTokenHelper";
import Books from "./pages/BookList";
import Categories from "./pages/CategoryList";

function App() {
    const authToken = localStorage.getItem("AuthToken");
    const history = useHistory();

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
            link: StringResource.linkBookList,
            name: "Book list"
        },
        {
            link: StringResource.linkCategoryList,
            name: "Category list"
        },
        {
            link: StringResource.linkLogout,
            name: "Logout",
        },
    ];

    const [alertMessage, setAlertMessage] = useState<AlertMessage>({
        message: "",
        type: "danger",
    });

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

                                        {localStorage.getItem(StringResource.admin) !== null ?? 
                                            <li className="nav-item dropdown">
                                                <a
                                                    className="nav-link dropdown-toggle"
                                                    id="adminNavigation"
                                                    data-toggle="dropdown"
                                                    aria-haspopup="true"
                                                    aria-expanded="false"
                                                    role="button"
                                                >
                                                    Admin
                                                </a>
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
                                        }
                                    </ul>
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
                                    </form>
                                </div>
                            </nav>
                            <Switch>
                                <Route path={StringResource.linkUserProfile}>
                                    <UserProfile />
                                </Route>
                                <Route path={StringResource.linkBookList}>
                                    <Books />
                                </Route>
                                <Route path={StringResource.linkCategoryList}>
                                    <Categories />
                                </Route>
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
