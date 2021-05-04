const capitalize = (phrase: string) =>
    phrase.charAt(0).toUpperCase() + phrase.slice(1).toLowerCase();

export const StringFormatter = {
    capitalize,
    dateUS: (date:string) => new Date(
        Date.parse(date)
    ).toLocaleString("en-US"),
    getRequestStatus: (status: number) => {
        switch (status) {
            case 0: return "Pending";
            case 1: return "Approved";
            case 2: return "Rejected";
            default: return ""
        }
    },
    validationForMinLength: (field: string, minLength: number) =>
        `${capitalize(field)}'s length must be longer than ${minLength - 1} characters`,
    validationForRequired: (field: string) => `${capitalize(field)} is required`,
};

export default StringFormatter;
