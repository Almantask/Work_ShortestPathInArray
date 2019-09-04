export async function findShortestPath(array) {
    let uri = buildUri(array);
    let response = await fetch(uri);
    let data = await response.json;

    return data;
}

export async function isArrayEndReachable(array) {
    let uri = buildUri(array);
    let response = await fetch(uri);
    let data = await response.json;

    return data;
}

function buildUri(array) {
    if (!Array.isArray(array)) return "";

    let parameters = buildArrayParameters(array);

    let firstQueryParameter = "";
    if (array.length > 0) {
        firstQueryParameter = "?array=";
    }
    let uri = "https://localhost:44328/ArrayPathConfigurator/IsEndReachable" + firstQueryParameter + parameters;

    return uri;
}

function buildArrayParameters(array) {
    let parametersString = array.join("&array=");

    return parametersString;
}