extends CanvasLayer

@onready var left = $LeftScore
@onready var right = $RightScore
@onready var win_window = $ConfirmationDialog

static var lcurrent = 0
static var rcurrent = 0

func _ready():
	left.frame = 0
	right.frame = 0
	lcurrent = 0
	rcurrent = 0
	
func _process(_delta):
	if lcurrent == 9:
		get_tree().paused = true
		win_window.title = "Player Wins!"
		win_window.visible = true
	if rcurrent == 9:
		get_tree().paused = true
		win_window.title = "Computer Wins!"
		win_window.visible = true
	left.frame = lcurrent
	right.frame = rcurrent

static func left_up():
	lcurrent += 1

static func right_up():
	rcurrent += 1

func _on_confirmation_dialog_confirmed():
	get_tree().paused = false
	win_window.visible = false
	get_tree().reload_current_scene()
	

func _on_confirmation_dialog_canceled():
	win_window.visible = false
	get_tree().quit()
