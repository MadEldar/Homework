import "./App.css";
import { Switch, Route, useHistory } from "react-router-dom";
import Login from "./pages/Login";
import UserProfile from "./pages/UserProfile";
import Alert from "./components/Alert";
import { useEffect, useState } from "react";
import AlertMessage from "./models/AlertMessage";
import StringResource from "./resources/StringResource";
import { logout } from "./helpers/LocalStorageHelper";
import BookList from "./pages/BookList";
import CategoryList from "./pages/CategoryList";
import AdminBookList from "./pages/Admin/BookList";
import AdminBookCreate from "./pages/Admin/BookCreate";
import AdminBookEdit from "./pages/Admin/BookEdit";
import NewRequest from "./pages/NewRequest";
import AdminCategoryList from "./pages/Admin/CategoryList";
import AdminCategoryCreate from "./pages/Admin/CategoryCreate";
import CategoryDetails from "./pages/CategoryDetails";
import BookDetails from "./pages/BookDetails";
import NavigationBar from "./components/NavigationBar";
import AdminUserList from "./pages/Admin/UserList";
import AdminUserDetails from "./pages/Admin/UserDetails";
import AdminRequestList from "./pages/Admin/RequestList";
import AdminCategoryDetails from "./pages/Admin/CategoryDetails";
import AdminBookDetails from "./pages/Admin/BookDetails";

function App() {
    const [isAdmin, setIsAdmin] = useState(localStorage.getItem(StringResource.admin) !== null);
    const authToken = localStorage.getItem("AuthToken");
    const history = useHistory();

    if (
        (!authToken || authToken === "") &&
        history.location.pathname !== StringResource.linkLogin
    ) {
        history.push(StringResource.linkLogin);
    } else if (
        authToken &&
        authToken !== "" &&
        history.location.pathname === StringResource.linkLogin
    ) {
        history.push(StringResource.linkHome);
    }

    const routes: { link: string; page: JSX.Element }[] = [
        {
            link: StringResource.linkHome,
            page: <div className="container">
                <h3 className="text-center">Welcome</h3>
            </div>,
        },
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
            link: StringResource.linkAdminBookDetails + ":id",
            page: <AdminBookDetails />,
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
            link: StringResource.linkAdminBookList,
            page: <AdminBookList />,
        },
        {
            link: StringResource.linkAdminCategoryCreate,
            page: <AdminCategoryCreate />,
        },
        {
            link: StringResource.linkAdminCategoryDetails + ":id",
            page: <AdminCategoryDetails />,
        },
        {
            link: StringResource.linkAdminCategoryList,
            page: <AdminCategoryList />,
        },
        {
            link: StringResource.linkAdminRequestList,
            page: <AdminRequestList />,
        },
        {
            link: StringResource.linkAdminUserList,
            page: <AdminUserList />,
        },
        {
            link: StringResource.linkAdminUserDetails + ":id",
            page: <AdminUserDetails />,
        },
    ];

    const [alertMessage, setAlertMessage] = useState<AlertMessage>({
        message: "",
        type: "danger",
    });

    useEffect(() => {
        setIsAdmin(localStorage.getItem(StringResource.admin) !== null);
    }, [authToken]);

    return (
        <div className="container">
            <div id="app-root" className="row">
                <Alert
                    message={alertMessage.message}
                    type={alertMessage.type}
                    statusCode={alertMessage.statusCode}
                />
                <Switch>
                    <Route path={StringResource.linkLogin}>
                        <Login setAlertMessage={setAlertMessage} />
                    </Route>
                    <Route path={StringResource.linkHome}>
                        <NavigationBar isAdmin={isAdmin} />
                        <Switch>
                            {routes.map((r) => (
                                <Route path={r.link} exact key={r.link}>
                                    {r.page}
                                </Route>
                            ))}
                            <Route path={StringResource.linkLogout}>
                                {() => logout()}
                            </Route>
                        </Switch>
                    </Route>
                </Switch>
            </div>
        </div>
    );
}

export default App;
