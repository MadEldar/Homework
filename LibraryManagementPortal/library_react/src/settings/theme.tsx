import { createMuiTheme } from "@material-ui/core/styles";

export const theme = createMuiTheme({
    palette: {
        primary: {
            light: "#4fc3f7",
            main: "#3f50b5",
            dark: "#002884",
            contrastText: "#fff",
        },
        secondary: {
            light: "#4dd0e1",
            main: "#f44336",
            dark: "#ba000d",
            contrastText: "#000",
        },
    },
});

export default theme;