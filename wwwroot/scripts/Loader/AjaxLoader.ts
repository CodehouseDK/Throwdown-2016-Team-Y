
export class AjaxLoader {

    getJson(url: string, success: Function, error: Function, owner:any) {
        var xhr = new XMLHttpRequest();

        xhr.onreadystatechange = () => {
            if (xhr.readyState === 4) {
                if (xhr.status === 200) {
                    success(JSON.parse(xhr.responseText), owner);
                } else {
                    error(xhr.responseText, xhr.status, owner);
                }
            }
        };
        xhr.open("GET", url);
        xhr.send();
    }

    postJson(url: string, data: any, success: Function, error: Function) {
        var xhr = new XMLHttpRequest();

        xhr.onreadystatechange = () => {
            if (xhr.readyState === 4) {
                if (xhr.status === 200) {
                    if (xhr.responseText === '') {
                        success('');
                    } else {
                        success(JSON.parse(xhr.responseText));
                    }
                } else {
                    error(xhr.responseText, xhr.status);
                }
            }
        };
        xhr.open("POST", url);
        xhr.setRequestHeader('Content-Type', 'application/json');
        xhr.send(JSON.stringify(data));
    }
}