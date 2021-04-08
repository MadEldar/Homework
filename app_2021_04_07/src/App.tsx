import "./App.css";
import NotificationSettings from "./components/NotificationSetting";
import RatingBar from "./components/RatingBar";
import Home from "./pages/Home";
import { LineChart } from "./components/Chart";
import { useState } from "react";
import { BrowserRouter as Router, Switch, Route, Link } from "react-router-dom";
import Login from "./pages/Login";
import Register from "./pages/Register";
import { ProductCreate } from "./pages/Product";

interface NavigationLink {
    name: string,
    link: string
}

function App() {
    const [show, setShow] = useState(true);

    const navigationLinks = [{
        name: "Home",
        link: "/link"
    }, {
        name: "Login",
        link: "/login"
    }, {
        name: "Register",
        link: "/register"
    }, {
        name: "Create product",
        link: "/create-product"
    }, {
        name: "Settings",
        link: "/notification-settings"
    }, {
        name: "Rating bar",
        link: "/rating-bar"
    }, {
        name: "Line chart",
        link: "/line-chart"
    }, ]

    return (
        <div className="container">
            <div className="row">
                <Router>
                    <div className="container col-12">
                        <ul className="row list-unstyled">
                            {navigationLinks.map(nav => 
                                <li key={nav.link.replace("/", "")} className="px-3">
                                    <Link to={nav.link}>{nav.name}</Link>
                                </li>
                            )}
                        </ul>
                    </div>
                    <Switch>
                        <Route path="/home" exact={true}>
                            <Home />
                        </Route>
                        <Route path="/login" exact={true}>
                            <Login />
                        </Route>
                        <Route path="/register" exact={true}>
                            <Register />
                        </Route>
                        <Route path="/create-product" exact={true}>
                            <ProductCreate />
                        </Route>
                        <Route path="/notification-settings">
                            <NotificationSettings />
                        </Route>
                        <Route path="/rating-bar">
                            <RatingBar />
                        </Route>
                        <Route path="/line-chart">
                            <button onClick={() => setShow(!show)}>
                                {show ? "Hide" : "Show"}
                            </button>
                            {show && <LineChart />}
                        </Route>
                    </Switch>
                </Router>
            </div>
        </div>
    );
}

export default App;
