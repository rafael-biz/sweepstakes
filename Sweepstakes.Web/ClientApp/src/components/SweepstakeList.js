import React from 'react';
import axios from 'axios';
import List from '@material-ui/core/List';
import ListItem from '@material-ui/core/ListItem';
import ListItemText from '@material-ui/core/ListItemText';
import ListItemSecondaryAction from '@material-ui/core/ListItemSecondaryAction';
import PersonAddIcon from '@material-ui/icons/PersonAdd';
import IconButton from '@material-ui/core/IconButton';

export default class SweepstakesList extends React.Component {
    state = {
        sweepstakes: []
    }

    componentDidMount() {
        axios.get(`/api/sweepstakes`)
            .then(res => {
                const sweepstakes = res.data;
                this.setState({ sweepstakes });
            })
    }

    render() {
        return (
            <List>
                { this.state.sweepstakes.map((item) => (
                    <ListItem>
                        <ListItemText primary={item.name} secondary={item.description} />
                        <ListItemSecondaryAction>
                            <IconButton edge="end" aria-label="comments">
                                <PersonAddIcon />
                            </IconButton>
                        </ListItemSecondaryAction>
                    </ListItem>
                ))}
            </List>
        )
    }
}