class Hello extends React.Component {
    render() {
        return <div>
            <h1>Заголовок</h1>
            <p>Описание</p>
        </div>;
    }
}

class Sponsor extends React.Component {
    constructor(props) {
        super(props);
        this.state = { data: props.sponsor };
        this.onClick = this.onClick.bind(this);
    }
    onClick(e) {
        this.props.onRemove(this.state.data);
    }
    render() {
        return <div>
            <p>{this.state.data.Name}</p>
            <p>{this.state.data.Phone}</p>
            <p>{this.state.data.Email}</p>
            <p>{this.state.data.Address}</p>
            <p><button onClick={this.onClick}>delete</button></p>
        </div>;
    }
}

class FormSponsor extends React.Component {
    constructor(props) {
        super(props);
        this.state = { Name: "", Phone: "", Email: "", Address: "" };
        this.onSubmit = this.onSubmit.bind(this);
        this.onNameChange = this.onNameChange.bind(this);
        this.onPhoneChange = this.onPhoneChange.bind(this);
        this.onEmailChange = this.onEmailChange.bind(this);
        this.onAddressChange = this.onAddressChange.bind(this);
    }
    onNameChange(e) {
        this.setState({ Name: e.target.value });
    }
    onPhoneChange(e) {
        this.setState({ Phone: e.target.value });
    }
    onEmailChange(e) {
        this.setState({ Email: e.target.value });
    }
    onAddressChange(e) {
        this.setState({ Address: e.target.value });
    }
    onSubmit(e) {
        e.preventDefault();
        var sponName = this.state.Name.trim();
        var sponPhone = this.state.Phone.trim();
        var sponEmail = this.state.Email.trim();
        var sponAddress = this.state.Address.trim();
        if (!sponName || !sponAddress || !sponEmail || !sponPhone) {
            return;
        }
        this.props.onSponSubmit({ Name: sponName, Phone: sponPhone, Email: sponEmail, Address: sponAddress });
        this.setState({ Name: "", Phone: "", Email: "", Address: "" });
    }
    render() {
        return (
            <form onSubmit={this.onSubmit}>
                <p>
                    <input type="text" placeholder="name" value={this.state.Name} onChange={this.onNameChange} />
                </p>
                <p>
                    <input type="text" placeholder="phone" value={this.state.Phone} onChange={this.onPhoneChange} />
                </p>
                <p>
                    <input type="text" placeholder="email" value={this.state.Email} onChange={this.onEmailChange} />
                </p>
                <p>
                    <input type="text" placeholder="address" value={this.state.Address} onChange={this.onAddressChange} />
                </p>
                <input type="submit" value="Save" />
            </form>
        );
    }
}

class SponsorsList extends React.Component {
    constructor(props) {
        super(props);
        this.state = { sponsors: [] };
        this.onAddSpon = this.onAddSpon.bind(this);
        this.onRemoveSpon = this.onRemoveSpon.bind(this);
    }
    loadData() {
        var xhr = new XMLHttpRequest();
        xhr.open("get", this.props.apiUrl, true);
        xhr.onload = function () {
            var data = JSON.parse(xhr.responseText);
            this.setState({ sponsors: data });
        }.bind(this);
        xhr.send();
    }
    componentDidMount() {
        this.loadData();
    }
    onAddSpon(sponsor) {
        if (sponsor) {
            const data = new FormData();
            data.append("Name", sponsor.Name);
            data.append("Phone", sponsor.Phone);
            data.append("Email", sponsor.Email);
            data.append("Address", sponsor.Address);
            var xhr = new XMLHttpRequest();
            xhr.open("post", this.props.apiUrl, true);
            xhr.onload = function () {
                if (xhr.status === 200) {
                    this.loadData();
                }
            }.bind(this);
            xhr.send(data);
        }
    }
    onRemoveSpon(sponsor) {
        if (sponsor) {
            var url = this.props.apiUrl + "/" + sponsor.id;
            var xhr = new XMLHttpRequest();
            xhr.open("delete", url, true);
            xhr.setRequestHeader("Content-Type", "application/json");
            xhr.onload = function () {
                if (xhr.status === 200) {
                    this.loadData();
                }
            }.bind(this);
            xhr.send();
        }
    }
    render() {
        var remove = this.onRemoveSpon;
        return <div>
            <Hello />
            <FormSponsor onSponSubmit={this.onAddSpon} />
            <h2>Список</h2>
            <div>
                {
                    this.state.sponsors.map(function (sponsor) {
                        return <Sponsor key={sponsor.id} sponsor={sponsor} onRemove={remove} />
                    })
                }
            </div>
        </div>;
    }
}

ReactDOM.render(
    <SponsorsList apiUrl="/api/sponsors" />,
    document.getElementById("content")
);
