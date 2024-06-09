extends CanvasLayer

@onready var left = $LeftScore
@onready var right = $RightScore

static var lcurrent = 0
static var rcurrent = 0

func _ready():
	left.frame = 0
	right.frame = 0
	lcurrent = 0
	rcurrent = 0
	
func _process(_delta):
	if lcurrent == 9:
		pass
	if rcurrent == 9:
		pass
	left.frame = lcurrent
	right.frame = rcurrent

static func left_up():
	lcurrent += 1
	print("Left Score")

static func right_up():
	rcurrent += 1
	print("Right Score")
