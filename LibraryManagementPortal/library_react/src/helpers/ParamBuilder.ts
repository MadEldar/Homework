export default function ParamBuilder(params: {[key: string]: string}) {
    let query = "?";

    for (const key in params) {
        if (Object.prototype.hasOwnProperty.call(params, key)) {
            const value = params[key];
            query += `${key}=${value}&`;
        }
    }

    return query.slice(0, -1);
}