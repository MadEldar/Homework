import "./App.css";
import { Container, ThemeProvider } from "@material-ui/core";
import { BrowserRouter as Router, Switch, Link, Route } from "react-router-dom";
import Login from "./pages/Login";
import theme from "./settings/theme";

function App() {
    return (
        <ThemeProvider theme={theme}>
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
        </ThemeProvider>
    );
}

export default App;
