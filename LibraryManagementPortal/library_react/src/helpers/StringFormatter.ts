const capitalize = (phrase: string) =>
    phrase.charAt(0).toUpperCase() + phrase.slice(1).toLowerCase();

export const StringFormatter = {
    capitalize,
    validationForMinLength: (field: string, minLength: number) =>
        `${capitalize(field)}'s length must be longer than ${minLength} characters`,
    validationForRequired: (field: string) => `${capitalize(field)} is required`,
};

export default StringFormatter;
