import "./App.css";
import { Container, ThemeProvider } from "@material-ui/core";
import { BrowserRouter as Router, Switch, Link, Route } from "react-router-dom";
import Login from "./pages/Login";
import theme from "./settings/theme";
import { AppContext, defaultContext } from "./AppContext";

function App() {
    return (
        <AppContext.Provider value={defaultContext}>
            <Container>
                <Router>
                    <ul>
                        <li>
                            <Link to="/login">Login</Link>
                        </li>
                    </ul>
                    <Switch>
                        <Route path="/login">
                            <Login />
                        </Route>
                    </Switch>
                </Router>
            </Container>
        </AppContext.Provider>
    );
}

export default App;
