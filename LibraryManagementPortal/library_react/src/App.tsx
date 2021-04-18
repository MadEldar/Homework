import "./App.css";
import { Container } from "@material-ui/core";
import { BrowserRouter as Router, Switch, Link, Route } from "react-router-dom";
import Login from "./pages/Login";
import { AppContext, defaultContext } from "./AppContext";
import { useState, useContext } from "react";

function App() {
    const { username, role } = useContext(AppContext);    
    return (
        <AppContext.Provider value={defaultContext}>
            <Container>
                <button onClick={() => console.log(username)}>
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
        </AppContext.Provider>
    );
}

export default App;
