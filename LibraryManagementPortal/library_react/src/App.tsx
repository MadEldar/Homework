import "./App.css";
import { Container } from "@material-ui/core";
import { BrowserRouter as Router, Switch, Link, Route } from "react-router-dom";
import Login from "./pages/Login";
import { AppContext } from "./AppContext";
import { useState, useContext, Dispatch, SetStateAction } from "react";

function App() {
    const { token, setToken } = useContext(AppContext) as {
        token: string,
        setToken: Dispatch<SetStateAction<string>>
    }
    
    return (
        <Container>
            <button onClick={() => setToken("mytoken")}>
                Click me
            </button>
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
    );
}

export default App;
